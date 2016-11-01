using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace RetailCharDump
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetStringBetween(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            if (LastString == Environment.NewLine)
                FinalString = STR.Substring(Pos1, STR.Length - Pos1);
            else
                FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        public long ConvertDateTimeToTimestamp(string date)
        {
            string[] str = date.Split(' ');
            string[] ddmmaaaa = str[0].Split('/');
            int month = Convert.ToInt16(ddmmaaaa[0]);
            int day = Convert.ToInt16(ddmmaaaa[1]);
            int year = Convert.ToInt16(ddmmaaaa[2]);

            string[] hhmmss = str[1].Split(':');
            int hour = Convert.ToInt16(hhmmss[0]);
            int minute = Convert.ToInt16(hhmmss[1]);
            int sec = Convert.ToInt16(hhmmss[2]);

            DateTime datetime = new DateTime(year, month, day, hour, minute, sec);
            var timeSpan = (datetime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        private void ScanBTN_Click(object sender, EventArgs e)
        {
            bool EnteredOpcode = false;
            string FoundOpcode = String.Empty;

            /*SEND KNOWN SPELLS VARIABLES (dbtable: character_spell)*/
            bool SEND_KNOWN_SPELLS = false;
            string KnownSpellsCount = String.Empty;
            int ParsedKnownSpells = 0;
            List<int> SpellIDList = new List<int>();

            /*ALL ACHIEVEMENT DATA VARIABLES dbtable: character_achievement & character_achievement_progress*/
            bool ALL_ACHIEVEMENT_DATA = false;
            string EarnedCount = String.Empty;
            string ProgressCount = String.Empty;
            int ParsedAchiCount = 0;
            int ParsedProgAchiCount = 0;
            List<long> DateAchi = new List<long>();
            List<int> AchiID = new List<int>();
            List<int> AchiProgID = new List<int>();
            List<int> QuantityAchiProg = new List<int>();
            List<long> DateAchiProg = new List<long>();

            /*UPDATE OBJECT VARIABLES*/
            bool UPDATE_OBJECT = false;
            string NumObjUpdates = String.Empty;
            int ParsedObjUpdates = 0;
            int DetectedItems = 0;
            bool ObjUpdateItem = false;
            List<int> ItemEntry = new List<int>();
            List<int> ItemCount = new List<int>();
            List<int> ItemFlags = new List<int>();
            List<int> ItemDurability = new List<int>();

            int counter = 0;
            string line = String.Empty;
            statusLBL.ResetText();
            statusLBL.Text = "INITIAL SCANNING";
            statusLBL.Refresh();
            StreamReader file = new StreamReader($"{SniffFileName.Text}.txt");
            while ((line = file.ReadLine()) != null)
            {
                statusLBL.Text = $"SCANNING LINE {counter++}";
                statusLBL.Refresh();

                /**************\
                 * Elaboration*
                \**************/
                if (!EnteredOpcode)
                {
                    if (line.Contains("SMSG_SEND_KNOWN_SPELLS") && !SEND_KNOWN_SPELLS)
                    {
                        EnteredOpcode = true;
                        SEND_KNOWN_SPELLS = true;
                        FoundOpcode = "SMSG_SEND_KNOWN_SPELLS";
                    }   

                    if(line.Contains("SMSG_ALL_ACHIEVEMENT_DATA") && !ALL_ACHIEVEMENT_DATA)
                    {
                        EnteredOpcode = true;
                        ALL_ACHIEVEMENT_DATA = true;
                        FoundOpcode = "SMSG_ALL_ACHIEVEMENT_DATA";
                    }

                    if(line.Contains("SMSG_UPDATE_OBJECT") && !UPDATE_OBJECT) //We have player item only in the first strike of this opcode?
                    {
                        EnteredOpcode = true;
                        UPDATE_OBJECT = true;
                        FoundOpcode = "SMSG_UPDATE_OBJECT";
                    }
                }
                else
                {
                    switch(FoundOpcode)
                    {
                        case "SMSG_SEND_KNOWN_SPELLS":
                            if (KnownSpellsCount != "" && Convert.ToInt16(KnownSpellsCount) == ParsedKnownSpells)
                                EnteredOpcode = false;

                            if(line.Contains("KnownSpellsCount"))
                                KnownSpellsCount = GetStringBetween(line, "KnownSpellsCount: ", " (");

                            if(line.Contains("KnownSpellId"))
                            {
                                SpellIDList.Add(Convert.ToInt32(GetStringBetween(line, "KnownSpellId: ", " (")));
                                ParsedKnownSpells++;
                            }
                            break;
                        case "SMSG_ALL_ACHIEVEMENT_DATA":
                            if ((EarnedCount != "" && Convert.ToInt32(EarnedCount) == ParsedAchiCount) && (ProgressCount != "" && Convert.ToInt32(ProgressCount) == ParsedProgAchiCount))
                                EnteredOpcode = false;

                            if (line.Contains("EarnedCount"))
                                EarnedCount = GetStringBetween(line, "EarnedCount: ", " (");

                            if (line.Contains("ProgressCount"))
                                ProgressCount = GetStringBetween(line, "ProgressCount: ", " (");

                            if (line.Contains("Earned") && line.Contains("Id"))
                            {
                                AchiID.Add(Convert.ToInt32(GetStringBetween(line, "Id: ", " (")));
                                ParsedAchiCount++;
                            }

                            if (line.Contains("Earned") && line.Contains("Date"))
                                DateAchi.Add(ConvertDateTimeToTimestamp(GetStringBetween(line, "Date: ", Environment.NewLine)));

                            if (line.Contains("Progress") && line.Contains("Id"))
                            {
                                AchiProgID.Add(Convert.ToInt32(GetStringBetween(line, "Id: ", " (")));
                                ParsedProgAchiCount++;
                            }

                            if (line.Contains("Progress") && line.Contains("Date"))
                                DateAchiProg.Add(ConvertDateTimeToTimestamp(GetStringBetween(line, "Date: ", Environment.NewLine)));

                            if (line.Contains("Progress") && line.Contains("Quantity"))
                                QuantityAchiProg.Add(Convert.ToInt32(GetStringBetween(line, "Quantity: ", " (")));

                            break;
                        case "SMSG_UPDATE_OBJECT":
                            if (NumObjUpdates != "" && Convert.ToInt16(NumObjUpdates) == ParsedObjUpdates)
                                EnteredOpcode = false;

                            if (line.Contains("NumObjUpdates"))
                                NumObjUpdates = GetStringBetween(line, "NumObjUpdates: ", " (");

                            if(line.Contains("Object Type"))
                            {
                                ParsedObjUpdates++;
                                if (line.Contains("Item"))
                                {
                                    ObjUpdateItem = true;
                                    DetectedItems++;
                                }
                                else
                                    ObjUpdateItem = false;
                            }
                            if (ObjUpdateItem)
                            {
                                if (line.Contains("OBJECT_FIELD_ENTRY"))
                                    ItemEntry.Add(Convert.ToInt32(GetStringBetween(line, "OBJECT_FIELD_ENTRY: ", "/")));

                                if (line.Contains("ITEM_FIELD_FLAGS"))
                                    ItemFlags.Add(Convert.ToInt32(GetStringBetween(line, "ITEM_FIELD_FLAGS: ", "/")));
                                else
                                    ItemFlags.Add(1);

                                if (line.Contains("ITEM_FIELD_STACK_COUNT"))
                                    ItemCount.Add(Convert.ToInt32(GetStringBetween(line, "ITEM_FIELD_STACK_COUNT: ", "/")));

                                if (line.Contains("ITEM_FIELD_MAXDURABILITY"))
                                    ItemDurability.Add(Convert.ToInt32(GetStringBetween(line, "ITEM_FIELD_MAXDURABILITY: ", "/")));
                                else
                                    ItemDurability.Add(0);

                            }
                            break;
                    }
                }

                CharInfoRTB.AppendText($"{line} {Environment.NewLine}");
                counter++;
            }
            file.Close();

            statusLBL.ResetText();
            statusLBL.Text = "CREATING SQL..";
            statusLBL.Refresh();

            int CharGuid = Convert.ToInt32(CharGuidTXT.Text);

            SqlOutRTB.AppendText($"-- Character Spells {Environment.NewLine}");
            SqlOutRTB.AppendText($"DELETE FROM `character_spell` WHERE `guid` = {CharGuid}; {Environment.NewLine}");
            foreach (var spellID in SpellIDList)
                SqlOutRTB.AppendText($"INSERT INTO `character_spell`(`guid`, `spell`, `active`, `disabled`) VALUES({CharGuid}, {spellID}, 1, 0); {Environment.NewLine}");

            SqlOutRTB.AppendText($"-- Character Achievement {Environment.NewLine}");
            SqlOutRTB.AppendText($"DELETE FROM `character_achievement` WHERE `guid` = {CharGuid}; {Environment.NewLine}");
            for (int i = 0; i < AchiID.Count; i++)
                SqlOutRTB.AppendText($"INSERT INTO `character_achievement`(`guid`, `achievement`, `date`) VALUES({CharGuid}, {AchiID[i]}, {DateAchi[i]}); {Environment.NewLine}");

            SqlOutRTB.AppendText($"-- Character Achievement In Progress {Environment.NewLine}");
            SqlOutRTB.AppendText($"DELETE FROM `character_achievement_progress` WHERE `guid` = {CharGuid}; {Environment.NewLine}");
            for (int i = 0; i < AchiProgID.Count; i++)
                SqlOutRTB.AppendText($"INSERT INTO `character_achievement_progress`(`guid`, `criteria`, `counter`, `date`) VALUES({CharGuid}, {AchiProgID[i]}, {QuantityAchiProg[i]}, {DateAchiProg[i]}); {Environment.NewLine}");

            SqlOutRTB.AppendText($"-- Character Item Instance {Environment.NewLine}");
            SqlOutRTB.AppendText($"DELETE FROM `item_instance` WHERE `owner_guid` = {CharGuid}; {Environment.NewLine}");
            MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=characters;Uid=root;Pwd=ascent;");
            conn.Open();
            for(int i = 0; i < ItemEntry.Count; i++)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT max(`guid`) as 'maxguid' FROM `item_instance`;", conn);
                MySqlDataReader r = cmd.ExecuteReader();
                int maxguid = 0;
                while (r.Read())
                    maxguid = Convert.ToInt32(r["maxguid"]);
                r.Close();
                SqlOutRTB.AppendText($"INSERT INTO `item_instance`(`guid`, `owner_guid`, `itemEntry`, `count`, `flags`, `durability`) VALUES({maxguid}, {CharGuid}, {ItemEntry[i]}, {ItemCount[i]}, {ItemFlags[i]}, {ItemDurability[i]}); {Environment.NewLine}");
            }
            conn.Close();
            statusLBL.ResetText();
            statusLBL.Text = "NO STATUS";
            statusLBL.Refresh();
        }
    }
}
