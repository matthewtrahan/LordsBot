using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsBot.Bot
{
    public static class BuildingUpgrade
    {
        public static bool BuildingUpGradeFound(int handler)
        {
            return Common.SendMouseClickForTemplate(LordsBot.Properties.Resources.UpgradeBuildingButtonMtCropped, handler, 0.95);
        }

        public static bool BuildingUpGradeButton(int handler)
        {
            return Common.SendMouseClickForTemplate(LordsBot.Properties.Resources.UpgradeBuilding1Mt, handler);
        }

        public static bool ConfirmBuildingUpgrade(int handler)
        {
            return Common.SendMouseClickForTemplate(LordsBot.Properties.Resources.ConfirmUpgrade, handler);
        }
    }
}
