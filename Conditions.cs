using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace WaitUntilFullyRested {
  public abstract class Conditions {
    public static GameMenuOption.OnConditionDelegate waitUntilFullyRestedGameMenuOptionCondition = (MenuCallbackArgs args) => {
      CraftingCampaignBehavior craftingCampaignBehavior = CampaignBehaviorBase.GetCampaignBehavior<CraftingCampaignBehavior>();
      int currentStamina = craftingCampaignBehavior.GetHeroCraftingStamina(Hero.MainHero);
      int maxStamina = craftingCampaignBehavior.GetMaxHeroCraftingStamina(Hero.MainHero);

      TextObject disabledText;
      bool shouldBeDisabled;
      bool canPlayerDo = Campaign.Current.Models.SettlementAccessModel.CanMainHeroDoSettlementAction(
        Settlement.CurrentSettlement,
        SettlementAccessModel.SettlementAction.WaitInSettlement,
        out shouldBeDisabled,
        out disabledText
      );

      args.optionLeaveType = GameMenuOption.LeaveType.Wait;

      return MenuHelper.SetOptionProperties(args, canPlayerDo, shouldBeDisabled, disabledText) && currentStamina < maxStamina;
    };

    public static OnConditionDelegate waitUntilFullyRestedGameMenuCondition = (MenuCallbackArgs args) => {
      args.optionLeaveType = GameMenuOption.LeaveType.Wait;
      MBTextManager.SetTextVariable("CURRENT_SETTLEMENT", Settlement.CurrentSettlement.EncyclopediaLinkWithName, false);

      return true;
    };
  }
}