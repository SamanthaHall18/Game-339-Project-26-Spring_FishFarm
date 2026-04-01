using Game339.Shared.Models;
using TMPro;

namespace Game.Runtime
{
public class GoodGuyHpView : ObserverMonoBehaviour
{
    public TextMeshProUGUI thisIsMyLabel;

    public bool useAlternativeMessage;

    protected override void Subscribe()
    {
        var gameState = ServiceResolver.Resolve<GameState>();
        gameState.GoodGuy.Health.ChangeEvent += OnGoodGuyHealthChange;
    }

    protected override void Unsubscribe()
    {
        var gameState = ServiceResolver.Resolve<GameState>();
        gameState.GoodGuy.Health.ChangeEvent -= OnGoodGuyHealthChange;
    }

    private void OnGoodGuyHealthChange(int health)
    {
        if (useAlternativeMessage)
        {
            thisIsMyLabel.text = "WAT?? -" + health;
        }
        else
        {
            thisIsMyLabel.text = "Health: " + health;
        }
    }
}
}
