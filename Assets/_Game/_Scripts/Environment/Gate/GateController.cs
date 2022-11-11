using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour, ITriggerPlayer
{
    public OperationType operationType;

    public int amount;
    public TextMeshPro text;
    public Renderer rend;

    public Color32 positiveColor;
    public Color32 negativeColor;

    private void Awake()
    {
        InitGate();
    }
    void InitGate()
    {
        string txt = "";
        switch (operationType)
        {
            case OperationType.add:
                rend.material.color = positiveColor;
                txt = "+";
                break;
            case OperationType.substract:
                rend.material.color = negativeColor;
                txt = "-";
                break;
            case OperationType.multiply:
                rend.material.color = positiveColor;
                txt = "x";
                break;
            case OperationType.divide:
                rend.material.color = negativeColor;
                txt = "÷";
                break;
        }
        txt += amount.ToString();

        text.text = txt;
    }
    public void OnTrigger(PlayerStateMachine player)
    {
        int ballCount = player.stack.ActiveBalls.Count;
        int targetCount = 0;
        int operationCount = 0;
        switch (operationType)
        {
            case OperationType.add:
                player.stack.ActivateBalls(amount);
                break;
            case OperationType.substract:
                player.stack.DeactivateBalls(amount);
                break;
            case OperationType.multiply:
                targetCount = ballCount * (amount);
                operationCount = targetCount - ballCount;
                player.stack.ActivateBalls(operationCount);
                break;
            case OperationType.divide:
                targetCount = (int)(ballCount / amount);
                operationCount = ballCount - targetCount;
                player.stack.DeactivateBalls(operationCount);
                break;
        }
    }

}
