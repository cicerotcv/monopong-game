using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    public Text message;

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.vidas > 0)
        {
            message.text = "Você Ganhou!!!";
        }
        else
        {
            message.text = "Você foi de base!!";
        }
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
