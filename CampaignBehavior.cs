using TaleWorlds.CampaignSystem;

namespace WaitUntilFullyRested {
  public class CampaignBehavior : CampaignBehaviorBase {
    public override void RegisterEvents() {
      CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunchedEventHandler);
    }

    private void OnSessionLaunchedEventHandler(CampaignGameStarter campaignGameStarter) {
      TownMenus.register(campaignGameStarter);
      CastleMenus.register(campaignGameStarter);
    }

    public override void SyncData(IDataStore dataStore) { }
  }
}
