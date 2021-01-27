using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExSharpBase.Modules;
using Newtonsoft.Json.Linq;

namespace ExSharpBase
{
    class Program
    {
        public static Overlay.Base DrawBase = new Overlay.Base();
        public static Menu.BasePlate MenuBasePlate = new Menu.BasePlate();

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Task.Run(() => API.Service.IsLiveGameRunning());

                await Task.Run(() => LogService.Log("Found Live Instance of The Game."));

                await Task.Run(() => Events.EventsManager.SubscribeToEvents());

                await Task.Run(() => UnitRadiusService.ParseUnitRadiusData());

                await Task.Run(() => SpellDBService.ParseSpellDBData());

                await Task.Run(() => LogService.Log("Initialising Overlay Rendering..."));

                await Task.Run(() => DrawBase.Show());

            }).GetAwaiter().GetResult();
            while(!API.Service.IsLiveGameRunning()) {
                System.Threading.Thread.Sleep(1000);
            }
            API.Service.IsLiveGameRunning();
            LogService.Log("Found Live Instance of The Game.");
            // Events.EventsManager.SubscribeToEvents();
            UnitRadiusService.ParseUnitRadiusData();
            SpellDBService.ParseSpellDBData();
            LogService.Log("Initialising Overlay Rendering...");
            DrawBase.Show();
        }
    }
}
