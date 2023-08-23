using System;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Interfaces;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLib.Client.Events;
using System.Linq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Extensions;


namespace ConsoleApp7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;;
            Console.WriteLine("Bot Started.");
            Console.WriteLine("Write channel name.");
            new StartBot();
        }
    }

    class StartBot
    {
        int[] j = new int[4];
        TwitchClient client;
        string channelname = Console.ReadLine();
        public StartBot()
        {
            

            ConnectionCredentials credentials = new ConnectionCredentials("SnussedNigeria", "oauth:hw4p0mga517lgczeoz6k4jum9av94h");
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, channelname);
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnConnected += Client_OnConnected;
            client.Connect();
            Console.ReadKey();
        }
        
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            client.SendMessage(channelname, "/me Бот запущен. Это официальный бот Виталика Беласова по продаже латышского аутдора. Напишите !количество чтобы получить количество стафа в наличии. (Спасибо нашему спонсору !спонсор)");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Random rnd = new Random();
            string novid = "⠀";
            int a = rnd.Next(0, 5);
            int b = -1;
            int i;
            string[] p = new string[4] {"Марихуанна -  " , "Амфетамин - ", "ЛСД - ", "Метадон - " };
            string[] h = new string[4] { "Марихуанна", "Амфетамин", "ЛСД", "Метадон" };
            string[] hz = new string[4] { "марихуанны", "амфетамина", "лсд", "метадона" };
            string[] pz = new string[7] { "аньки", "равшана", "далера", "бислана", "денкза", "гледа", "витоло" };
            string[] lv = new string[0];
            int[] o = new int[0];
            int s = 0;

            
            if (e.ChatMessage.Message.Contains("!пополнение"))
            {
                
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }

                    for(i =0; i <= j.Length-1; i++)
                    {
                        if (j[i] == 0)
                        {
                            j[i] = rnd.Next(5, 40);
                            s = s + 1;
                            Array.Resize(ref o, (o.Length + 1));
                            o[(o.Length - 1)] = i;
                        }
                    }

                    if (s == 0)
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", Весь товар есть в наличии в данный момент." + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else
                    { 
                        for (i = 0; i <= o.Length-1; i++)
                        {
                        Array.Resize(ref lv, (o.Length));
                        lv[i] = h[i];
                        }

                        if (o.Length < 2)
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " " + String.Join(" ", lv) + " был успешно пополнен." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                        else
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " " + String.Join(", ", lv) + " были успешно пополнены." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                    }
                    a = rnd.Next(0, 5);
                    b = a;
                }
            }
            if (e.ChatMessage.Message.Contains("!глед"))
            {
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", ZГлед - CEO Талибана. Погиб 22 июня 2022 года, упав с коляски и ударившись затылком." + string.Concat(Enumerable.Repeat(novid, a)));
                    a = rnd.Next(0, 5);
                    b = a;
                }

            }
            if (e.ChatMessage.Message.Contains("!команды"))
            {
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", !наличие - проверить наличие товара, !хозяин <имя>, !купить <кол-во> грамм <наименование вещества>, !пополнение - пополнить склад." + string.Concat(Enumerable.Repeat(novid, a)));
                    a = rnd.Next(0, 5);
                    b = a;
                }

            }
            if (e.ChatMessage.Message.Contains("!купить"))
            {
                for (i = 1; i < 2; i++)
                {
                    

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    string lz = e.ChatMessage.Message;
                    
                    int op = lz.IndexOf(" ") + 1;
                    int op2 = lz.IndexOf(" ", op);
                    int k = Convert.ToInt32((lz.Substring(op, op2 - op)));
                    Console.WriteLine(k);


                    if (lz.Contains(hz[0]))
                    {
                        if (k > j[0])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", в данный момент нет " + k + " грамм марихуанны в наличии (!наличие)." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                        else if (k <= j[0])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " успешно приобрел " + k + " грамм марихуанны" + string.Concat(Enumerable.Repeat(novid, a)));
                            j[0] = j[0] - k;
                        }
                    }
                    else if (e.ChatMessage.Message.Contains(hz[1]))
                    {
                        if (k > j[1])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", в данный момент нет " + k + " грамм амфетамина в наличии (!наличие)." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                        else if (k <= j[1])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " успешно приобрел " + k + " грамм амфетамина" + string.Concat(Enumerable.Repeat(novid, a)));
                            j[1] = j[1] - k;
                        }
                        
                    }
                   
                    else if (e.ChatMessage.Message.Contains(hz[2]))
                    {
                        
                        if (k > j[2])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", в данный момент нет " + k + " грамм лсд в наличии (!наличие)." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                        else if (k <= j[2])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " успешно приобрел " + k + " грамм лсд" + string.Concat(Enumerable.Repeat(novid, a)));
                            j[2] = j[2] - k;
                        }
                    }
                    else if (e.ChatMessage.Message.Contains(hz[3]))
                    {
                        
                        if (k > j[3])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", в данный момент нет " + k + " грамм метадона в наличии (!наличие)." + string.Concat(Enumerable.Repeat(novid, a)));
                        }
                        else if (k <= j[3])
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + " успешно приобрел " + k + " грамм метадона" + string.Concat(Enumerable.Repeat(novid, a)));
                            j[3] = j[3] - k;
                        }
                    }

                    a = rnd.Next(0, 5);
                    b = a;
                }

            }
            if (e.ChatMessage.Message.Contains("!хозяин"))
            {
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    if (e.ChatMessage.Message.Contains(pz[0]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", Далер Махрамов." + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[1]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", ИП САМВЕЛ ОГАНДЖАНЯН СУРЕНОВИЧ." + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[2]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", СТИЛ TWITCH.TV/STEEL" + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[3]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", ЭРИК TWITCH.TV/DANKZLV" + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[4]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", ЭРИК АКОПЯН" + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[5]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", я." + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    else if (e.ChatMessage.Message.Contains(pz[6]))
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", Ахмад Исмаилгаджиев." + string.Concat(Enumerable.Repeat(novid, a)));
                    }

                    a = rnd.Next(0, 5);
                    b = a;
                }
            
            }

            if (e.ChatMessage.Message.Contains("!наличие"))
            {
                for (i = 1; i < 2; i++)
                {
                    

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    string[] k = new string[4] { p[0] + j[0], p[1] + j[1], p[2] + j[2], p[3] + j[3] };
                    client.SendMessage(channelname, "@" + e.ChatMessage.Username + " " + String.Join(" гр; ", k) + " гр." + string.Concat(Enumerable.Repeat(novid, a)));
                    a = rnd.Next(0, 5);
                    b = a;
                }
            }
            if (e.ChatMessage.Message.Contains("!спам"))
            {
                for (i = 1; i < 2; i++)
                {


                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    if (e.ChatMessage.Username == "snussed" || e.ChatMessage.Username == "segin737" ) 
                    {
                        string zk = e.ChatMessage.Message;
                        int psf = zk.IndexOf(" ")+1;
                        int psf2 = zk.IndexOf(" ", psf);
                        int cheslo = Convert.ToInt32(zk.Substring(psf, psf2 - psf));
                        string pedor = zk.Substring(psf2 + 1, zk.Length - psf2-1);
                        if (cheslo == 0)
                        {
                            client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", пошел нахуй");
                        }
                        else
                        {
                            for (i = 0; i < cheslo; i++)
                            {
                                client.SendMessage(channelname, pedor + string.Concat(Enumerable.Repeat(novid, a)));
                            }
                        }

                    }
                    else 
                    {
                        client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", " + "НИГEPY ПИДРОСЫ." + string.Concat(Enumerable.Repeat(novid, a)));
                    }
                    a = rnd.Next(0, 5);
                    b = a;
                }
            }
            if (e.ChatMessage.Message.Contains("!спонсор"))
            {
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", Наш спонсор по веществам Назарали Махрамов." + string.Concat(Enumerable.Repeat(novid, a)));
                    a = rnd.Next(0, 5);
                    b = a;
                }
            }
            if (e.ChatMessage.Message.Contains("!основание"))
            {
                for (i = 1; i < 2; i++)
                {

                    if (a == b)
                    {
                        while (a != b)
                        {
                            a = rnd.Next(0, 5);
                        }
                    }
                    client.SendMessage(channelname, "@" + e.ChatMessage.Username + ", @GondonBot был основан в 1939 году, в городе Монтенегро гледом." + string.Concat(Enumerable.Repeat(novid, a)));
                    a = rnd.Next(0, 5);
                    b = a;
                }
            }
        }

    }
}

// 1ASDDSA
