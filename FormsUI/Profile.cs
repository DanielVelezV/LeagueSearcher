using APIHelperDLL.Model;
using APIHelperDLL.Processor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class Profile : Form
    {
        List<LeagueModel> league;
        List<ChampionMasteryModel> champs;

        Dictionary<int, string> participantEntities;
        List<int> key;
        List<bool> Win;

        Dictionary<string, PictureBox> images;
        List<PictureBox> items;
        List<Panel> panels;
        List<PictureBox> spells;

        public Profile()
        {
            InitializeComponent();
            label1.Text = null;
            label2.Text = null;
            lbl_Nombre.Text = Form1.summoner.Name;
            participantEntities = new Dictionary<int, string>();
            key = new List<int>();
            Win = new List<bool>();

            

        }

        private async void Profile_Load(object sender, EventArgs e)
        {

            league = await LeagueProcessor.GetLeague(Form1.summoner.ID);
            champs = await ChampionMasteryProcessor.GetChampionsMastery(Form1.summoner.ID);

            pb_Champ1.ImageLocation = Form1.path + $@"Champs\{champs[0].ChampionID}.png";
            pb_Champ2.ImageLocation = Form1.path + $@"Champs\{champs[1].ChampionID}.png";
            pb_Champ3.ImageLocation = Form1.path + $@"Champs\{champs[2].ChampionID}.png";

            pictureBox1.ImageLocation = Form1.path + $@"Icons\icon_{Form1.summoner.ProfileIconID}.png";
            if (league.Capacity > 0)
            {
                pb_Division.ImageLocation = Form1.path + $@"Divs\{league[0].Tier.ToLower()}_{ConvertDiv(league[0].Rank)}.png";
                label2.Text = league[0].Rank;
            }
            else
            {
                pb_Division.ImageLocation = Form1.path + $@"Divs\default.png";
            }
           
            label1.Text = Form1.summoner.SummonerLevel.ToString();

            Text = $"{Form1.summoner.Name}'s Profile";



            //Carga de Partidas.

            images = new Dictionary<string, PictureBox>()
            {
                {"m1", m1_champ },{"m2", m2_champ },{"m3", m3_champ},{"m4", m4_champ},{"m5", m5_champ},
                {"m6", m6_champ },{"m7", m7_champ },{"m8", m8_champ},{"m9", m9_champ},{"m10", m10_champ}
            };

            items = new List<PictureBox>()
            {
                m1_item1, m1_item2, m1_item3, m1_item4, m1_item5, m1_item6,
                m2_item1, m2_item2, m2_item3, m2_item4, m2_item5, m2_item6,
                m3_item1, m3_item2, m3_item3, m3_item4, m3_item5, m3_item6,
                m4_item1, m4_item2, m4_item3, m4_item4, m4_item5, m4_item6,
                m5_item1, m5_item2, m5_item3, m5_item4, m5_item5, m5_item6,
                m6_item1, m6_item2, m6_item3, m6_item4, m6_item5, m6_item6,
                m7_item1, m7_item2, m7_item3, m7_item4, m7_item5, m7_item6,
                m8_item1, m8_item2, m8_item3, m8_item4, m8_item5, m8_item6,
                m9_item1, m9_item2, m9_item3, m9_item4, m9_item5, m9_item6,
                m10_item1, m10_item2, m10_item3, m10_item4, m10_item5, m10_item6
            };

            panels = new List<Panel>()
            {
                pn1, pn2, pn3, pn4, pn5, pn6, pn7, pn8, pn9, pn10
            };

            spells = new List<PictureBox>()
            {
                m1_spell1, m1_spell2,
                m2_spell1, m2_spell2,
                m3_spell1, m3_spell2,
                m4_spell1, m4_spell2,
                m5_spell1, m5_spell2,
                m6_spell1, m6_spell2,
                m7_spell1, m7_spell2,
                m8_spell1, m8_spell2,
                m9_spell1, m9_spell2,
                m10_spell1, m10_spell2
            };

            MatchModel Partidas = await MatchsProcessor.GetMatchsBySummoner(Form1.summoner.AccountID, 10);
            List<MatchParticipantModel> participantes = await MatchsProcessor.GetMatchs();

            foreach (var item in participantes)
            {
                foreach (var it in item.participantIdentities)
                {
                    if (it.player.SummonerName.ToLower() == Form1.summoner.Name.ToLower())
                    {
                        key.Add(it.ParticipantID);
                        break;
                    }
                }
            }

            List<ParticipantsDTO> parts = new List<ParticipantsDTO>();

            for (int i = 0; i < participantes.Count; i++)
            {
                for (int o = 0; o < 10; o++)
                {
                    if(participantes[i].participants[o].stats.ParticipantID == key[i])
                    {
                        parts.Add((participantes[i].participants[o]));
                        Win.Add(participantes[i].participants[o].stats.Win);
                    }
                }
            }
            int m = 0;
            foreach (var item in parts)
            {
                if (item != null)
                {
                    items[m].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item0}.png";
                    items[m + 1].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item1}.png";
                    items[m + 2].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item2}.png";
                    items[m + 3].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item3}.png";
                    items[m + 4].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item4}.png";
                    items[m + 5].ImageLocation = Form1.path + $@"Items\icon_{item.stats.Item5}.png";
                    m += 6;
                }   
            }

            
            for (int i = 0; i < Win.Count; i++)
            {
                if (Win[i])
                {
                    panels[i].BackColor = Color.ForestGreen;
                }
                else
                {
                    panels[i].BackColor = Color.IndianRed;
                }
            }


            for (int i = 0; i < Partidas.matches.Count; i++)
            {
                images[$"m{i + 1}"].ImageLocation = Form1.path + $@"Champs\{Partidas.matches[i].Champion}.png";                
            }

            int OuterCount = 0;
            for (int i = 0; i < parts.Count; i++)
            {
                spells[OuterCount].ImageLocation = Form1.path + $@"Spells\spell{parts[i].Spell1ID}.png";
                spells[OuterCount+1].ImageLocation = Form1.path + $@"Spells\spell{parts[i].Spell2ID}.png";
                OuterCount += 2;
            }

        }

        private string ConvertDiv(string Data)
        {
            switch (Data)
            {
                case "I":
                    return "1";
                case "II":
                    return "2";
                case "III":
                    return "3";
                case "IV":
                    return "4";
                default:
                    return "0";
            }
        }
    }
}
