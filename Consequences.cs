using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace WaitUntilFullyRested {
  public abstract class Consequences {
    public static GameMenuOption.OnConsequenceDelegate waitUntilFullyRestedGameMenuOptionConsequenceFactory(string menuToSwitchTo) {
      return new GameMenuOption.OnConsequenceDelegate((MenuCallbackArgs args) => {
        MenuContext currentMenuContext = Campaign.Current.CurrentMenuContext;

        currentMenuContext.SwitchToMenu(menuToSwitchTo);
      });
    }

    public static OnTickDelegate waitUntilFullyRestedGameMenuOnTickConsequenceFactory(string menuToReturnTo) {
      return new OnTickDelegate((MenuCallbackArgs args, CampaignTime dt) => {
        CraftingCampaignBehavior craftingCampaignBehavior = CampaignBehaviorBase.GetCampaignBehavior<CraftingCampaignBehavior>();
        MenuContext currentMenuContext = Campaign.Current.CurrentMenuContext;

        int currentStamina = craftingCampaignBehavior.GetHeroCraftingStamina(Hero.MainHero);
        int maxStamina = craftingCampaignBehavior.GetMaxHeroCraftingStamina(Hero.MainHero);

        if (currentStamina < maxStamina) return;

        InformationManager.DisplayMessage(
          new InformationMessage(
            new TextObject("{=CJEdNeG5TLNdk}You are fully rested!").ToString(),
            new Color(0.1f, 1f, 0.1f)
          )
        );

        currentMenuContext.GameMenu.EndWait();
        PlayerEncounter.Current.IsPlayerWaiting = false;
        currentMenuContext.SwitchToMenu(menuToReturnTo);
      });
    }

    public static GameMenuOption.OnConsequenceDelegate waitUntilFullyRestedGameMenuLeaveConsequenceFactory(string menuToReturnTo) {
      return new GameMenuOption.OnConsequenceDelegate((MenuCallbackArgs args) => {
        MenuContext currentMenuContext = Campaign.Current.CurrentMenuContext;

        currentMenuContext.GameMenu.EndWait();
        PlayerEncounter.Current.IsPlayerWaiting = false;
        currentMenuContext.SwitchToMenu(menuToReturnTo);
      });
    }
  }
}