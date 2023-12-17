/*
 * This class simulates card
 * 
 */

public class Card
{
    private int value;
    private string symbol;
    
    public Card(int value, string symbol)
    {
        this.value = value;
        this.symbol = symbol;
    }

    public int getValue()
    {
        return this.value;
    }

    public string getSymbol()
    {
        return this.symbol;
    }

}