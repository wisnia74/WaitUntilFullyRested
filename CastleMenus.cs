using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Overlay;

namespace WaitUntilFullyRested {
  public abstract class CastleMenus {
    public static void register(CampaignGameStarter campaignGameStarter) {
      AddGameMenuOptionsToDefaultCastleGameMenu(campaignGameStarter);
      AddNewCastleGameWaitMenu(campaignGameStarter);
      AddGameMenuOptionsToNewCastleGameWaitMenu(campaignGameStarter);
    }

    private static void AddGameMenuOptionsToDefaultCastleGameMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddGameMenuOption(
        "castle",
        "castle_wait_until_fully_rested",
        "{=3hLhzZ9nUCmZE}Wait here until you are fully rested",
        Conditions.waitUntilFullyRestedGameMenuOptionCondition,
        Consequences.waitUntilFullyRestedGameMenuOptionConsequenceFactory("castle_wait_until_fully_rested_menus"),
        false,
        10
      );
    }

    private static void AddNewCastleGameWaitMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddWaitGameMenu(
        "castle_wait_until_fully_rested_menus",
        "{=HRC4ChHx1QVOi}You are waiting in {CURRENT_SETTLEMENT} until you are fully rested.",
        (MenuCallbackArgs args) => {
          PlayerEncounter.Current.IsPlayerWaiting = true;
        },
        Conditions.waitUntilFullyRestedGameMenuCondition,
        null,
        Consequences.waitUntilFullyRestedGameMenuOnTickConsequenceFactory("castle"),
        GameMenu.MenuAndOptionType.WaitMenuHideProgressAndHoursOption,
        GameOverlays.MenuOverlayType.SettlementWithBoth
      );
    }

    private static void AddGameMenuOptionsToNewCastleGameWaitMenu(CampaignGameStarter campaignGameStarter) {
      campaignGameStarter.AddGameMenuOption(
        "castle_wait_until_fully_rested_menus",
        "castle_wait_until_fully_rested_menus_leave",
        "{=UqDNAZqM}Stop waiting",
        (MenuCallbackArgs args) => {
          args.optionLeaveType = GameMenuOption.LeaveType.Leave;

          return true;
        },
        Consequences.waitUntilFullyRestedGameMenuLeaveConsequenceFactory("castle"),
        true
      );
    }
  }
}