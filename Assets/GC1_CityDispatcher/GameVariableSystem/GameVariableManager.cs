using UnityEngine;

public enum GameVariablesEnum
{
    None = 0,
    Profit = 1,
    Poeple = 2,
    Planet = 3
}

public class GameVariablesManager : MonoBehaviour
{
    [SerializeField] private GameVariableClass _variableProfit = new();
    [SerializeField] private GameVariableClass _variablePoeple = new();
    [SerializeField] private GameVariableClass _variablePlanet = new();

    public GameVariableClass EnumToClass(GameVariablesEnum variable)
    {
        GameVariableClass thisVariable = null;

        switch (variable)
        {
            case GameVariablesEnum.None:
                // Do nothing.
                thisVariable = null;
                break;

            case GameVariablesEnum.Profit:
                // Return Profit Variable.
                thisVariable = _variableProfit;
                break;

            case GameVariablesEnum.Poeple:
                // Return Poeple Variable.
                thisVariable = _variablePoeple;
                break;

            case GameVariablesEnum.Planet:
                // Return Planet Variable.
                thisVariable = _variablePlanet;
                break;
        }

        return thisVariable;
    }

    private void Start()
    {
        _variableProfit.Restart();
        _variablePoeple.Restart();
        _variablePlanet.Restart();
    }

    public void AddCurrencyRelay(float amount, GameVariablesEnum variable)
    {
        GameVariableClass myVariable = EnumToClass(variable);
        if (myVariable != null)
            return;
        myVariable.AddCurrentValue(amount);
    }

    public void SubtractCurrencyRelay(float amount, GameVariablesEnum variable)
    {
        GameVariableClass myVariable = EnumToClass(variable);
        if (myVariable != null)
            return;
        myVariable.AddCurrentValue(amount);
    }
}
