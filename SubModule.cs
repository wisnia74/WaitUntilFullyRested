using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace WaitUntilFullyRested {
  public class SubModule : MBSubModuleBase {
    protected override void InitializeGameStarter(Game game, IGameStarter starterObject) {
      base.InitializeGameStarter(game, starterObject);
      if (starterObject is CampaignGameStarter starter) {
        starter.AddBehavior(new CampaignBehavior());
      }
    }
  }
}