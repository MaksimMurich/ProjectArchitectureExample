using Base;
using InGame;

namespace Assets.Scripts {
    public class ScenesManagerExample : SceneManagerBase {

        public override void InitializeSceneConfigs() {
            SceneConfigs[InGameSceneConfig.SCENE_NAME] = new InGameSceneConfig();
        }
    }
}
