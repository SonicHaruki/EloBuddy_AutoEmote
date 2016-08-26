using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Mastery_Emotion
{
    class Program
    {
        private static readonly string Author = "Haruki";
        private static readonly string AddonName = "Auto Emote";

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static Menu MasteryEmote;

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Mastery Emote - Addon by Haruki");
            Game.OnNotify += Game_OnNotify;
            MasteryEmote = MainMenu.AddMenu("MasteryEmote", "Mastery Emote" + " by " + Author + "v1.0");
            MasteryEmote.AddLabel(AddonName + " made by " + Author);

            MasteryEmote.Add("OnKill", new CheckBox("OnKill Emote", true));
            MasteryEmote.Add("OnAce", new CheckBox("OnAce Emote", true));
        }

        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId.Equals(GameEventId.OnChampionKill) && MasteryEmote["OnKill"].Cast<CheckBox>().CurrentValue)
            {
                Chat.Say("/masterybadge");
            }
            if (args.EventId.Equals(GameEventId.OnAce) && MasteryEmote["OnAce"].Cast<CheckBox>().CurrentValue)
            {
                Chat.Say("/masterybadge");
            }
        }
    }
}