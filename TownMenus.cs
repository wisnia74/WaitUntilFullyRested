using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Overlay;

namespace WaitUntilFullyRested {
  public abstract class TownMenus {
    public static void register(CampaignGameStarter campaignGameStarter) {
      AddGameMenuOptionsToDefaultTownGameMenu(campaignGameStarter);
      AddNewTownGameWaitMenu(campaignGameStarter);
      AddGameMenuOptionsToNewTownGameWaitMenu(campaignGameStarter);
    }

    private static void AddGameMenuOptionsToDefaultTownGameMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddGameMenuOption(
        "town",
        "town_wait_until_fully_rested",
        "{=3hLhzZ9nUCmZE}Wait here until you are fully rested",
        Conditions.waitUntilFullyRestedGameMenuOptionCondition,
        Consequences.waitUntilFullyRestedGameMenuOptionConsequenceFactory("town_wait_until_fully_rested_menus"),
        false,
        10
      );
    }

    private static void AddNewTownGameWaitMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddWaitGameMenu(
        "town_wait_until_fully_rested_menus",
        "{=HRC4ChHx1QVOi}You are waiting in {CURRENT_SETTLEMENT} until you are fully rested.",
        (MenuCallbackArgs args) => {
          PlayerEncounter.Current.IsPlayerWaiting = true;
        },
        Conditions.waitUntilFullyRestedGameMenuCondition,
        null,
        Consequences.waitUntilFullyRestedGameMenuOnTickConsequenceFactory("town"),
        GameMenu.MenuAndOptionType.WaitMenuHideProgressAndHoursOption,
        GameOverlays.MenuOverlayType.SettlementWithBoth
      );
    }

    private static void AddGameMenuOptionsToNewTownGameWaitMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddGameMenuOption(
        "town_wait_until_fully_rested_menus",
        "town_wait_until_fully_rested_menus_leave",
        "{=UqDNAZqM}Stop waiting",
        (MenuCallbackArgs args) => {
          args.optionLeaveType = GameMenuOption.LeaveType.Leave;

          return true;
        },
        Consequences.waitUntilFullyRestedGameMenuLeaveConsequenceFactory("town"),
        true
      );
    }
  }
}
