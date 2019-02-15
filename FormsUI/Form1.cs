using APIHelperDLL;
using APIHelperDLL.Model;
using APIHelperDLL.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static APIHelperDLL.Processor.SpectatorProcessor;

namespace FormsUI
{
    public partial class Form1 : Form
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static SummonerModel summoner;

        public List<SpectParticipantModel> participantes;
        TimeSpan T;
        long Length = 180;
        long ActualLength;
        bool reload = false;


        private List<Label> names;
        private List<PictureBox> champions;
        private List<PictureBox> spell1;
        private List<PictureBox> spell2;


        Dictionary<string, SpectParticipantModel> Data;
        Dictionary<string, SummonerModel> ProfileData;

        private void Form1_Load(object sender, EventArgs e)
        {
            APIHelper.InitializeClient();
            timer1.Enabled = false;
            gb_p.Visible = false; //Pone el Panel de partida invisible
            sm_search.Visible = false; //Pone "El invocador..." en invisible, solo se muestra cuando no encuentra los datos
            Data = new Dictionary<string, SpectParticipantModel>(); //Crea una data para revisar en el cache de la memoria y no en internet
            ProfileData = new Dictionary<string, SummonerModel>();


            foreach (var item in gb_p.Controls.OfType<Label>()) //En el evento de Click de cada Label le pone el metodo de ProfileForm
            {
                item.Click += ProfileForm;
            }

            //Mete todos los controles dentro de listas, para asi accederlos. Esto lo hice para poder ahorrar mucho codigo
            #region Inicializar Controles
            //Inicializar la lista de Labels
            names = new List<Label>()
            {
                sm1_Name, sm2_Name, sm3_Name, sm4_Name, sm5_Name, sm6_Name, sm7_Name, sm8_Name, sm9_Name, sm10_Name,
            };

            //Inicializar la lista de Champions
            champions = new List<PictureBox>()
            {
                sm1_champ, sm2_champ, sm3_champ, sm4_champ, sm5_champ, sm6_champ, sm7_champ, sm8_champ, sm9_champ, sm10_champ
            };

            //Inicializar la lista de Spell1
            spell1 = new List<PictureBox>()
            {
                sm1_spell1, sm2_spell1, sm3_spell1, sm4_spell1, sm5_spell1, sm6_spell1, sm7_spell1, sm8_spell1, sm9_spell1, sm10_spell1
            };

            //Inicializar la lista de Spell2
            spell2 = new List<PictureBox>()
            {
                sm1_spell2, sm2_spell2, sm3_spell2, sm4_spell2, sm5_spell2, sm6_spell2, sm7_spell2, sm8_spell2, sm9_spell2, sm10_spell2
            };
            #endregion 
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
                     
            SpectatorModel match; //Modelo de la partida.


            if (Data.ContainsKey(textBox1.Text.ToLower())) //Revisa si ya se ha buscado este summoner, y si es asi solo busca la partida.
            {
                match = await SpectateSummonerData(Data[textBox1.Text.ToLower()].summonerID); //Este ocurre si ya se ha buscado este summoner, simplemente usa el ID ya obtenido
            }
            else
            {
                match = await SpectateSummoner(textBox1.Text); //Este busca el Nombre y luego busca el ID, es decir: 2 Task, a diferencia de el de arriba que solo busca la partida
                if (match.participants != null)
                {
                    foreach (var item in match.participants)
                    {
                        if (!Data.ContainsKey(item.summonerName.ToLower()))
                        {
                            string name = item.summonerName.ToLower();
                            Data.Add(name, item); //Populo la lista con los 10 summoners y sus ID, asi me ahorro mas cuando sean muchas busquedas
                            ProfileData.Add(name, await SummonerProcessor.SearchSummoner(name));
                        }
                    }
                }
                reload = false;
            }

            
            if (match.participants != null) //Si hay una partida activa
            {
                participantes = match.participants;

                for (int i = 0; i < participantes.Count; i++) //Populo los labels y PictureBox
                {
                    names[i].Text = participantes[i].summonerName;


                    champions[i].ImageLocation = path + $@"\Champs\{participantes[i].ChampionID}.png"; 
                    spell1[i].ImageLocation = path + $@"\Spells\spell{participantes[i].spell1Id}.png";
                    spell2[i].ImageLocation = path + $@"\Spells\spell{participantes[i].spell2Id}.png";

                    
                    names[i].Visible = true;
                }

                if (reload)
                {
                    Length = ActualLength;
                }
                else
                {
                    Length = 180;
                    Length += match.GameLength; //Tiempo de partida en segundos.
                }


                lblTime.Text = ""; //label que tiene el tiempo
                timer1.Enabled = true; //Habilita el timer del tiempo
                timer1.Start(); //Empieza el timer
                lblGameMode.Text = match.gameMode;
                reload = true;
                gb_p.Visible = true; //Hago visible el Tablero de la partida
            }
            else
            {
                gb_p.Visible = false;
                sm_search.Text = $"El invocador '{textBox1.Text}' no existe o no se encuentra en partida"; //Hago visible el "El invocador..." e invisible el tablero de partida
                sm_search.Visible = true;                
            }

        }

        private void ProfileForm(object sender, EventArgs e) //Al hacer click en cualquier nombre simplemente abro un Form con la info del jugador.
        {
            Label lbl = (Label)sender;


            if (ProfileData.ContainsKey(lbl.Text.ToLower())) // Si ya el usuario fue buscado simplemente usa los datos en el cache de la APP
            {
                summoner = new SummonerModel()
                {
                    ProfileIconID = ProfileData[lbl.Text.ToLower()].ProfileIconID,
                    ID = ProfileData[lbl.Text.ToLower()].ID,
                    AccountID = ProfileData[lbl.Text.ToLower()].AccountID,
                    Name = ProfileData[lbl.Text.ToLower()].Name,
                    PUUID = ProfileData[lbl.Text.ToLower()].PUUID,
                    SummonerLevel = ProfileData[lbl.Text.ToLower()].SummonerLevel
                };
            }
            Profile form = new Profile();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            T = TimeSpan.FromSeconds(Length); //Convierte el tiempo de partida en (hh/mm/ss)
            Length++; //Añade 1s cada segundo
            lblTime.Text = T.ToString();
            ActualLength = Length;
        }
    }
}
