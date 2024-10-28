using System;
using UnityEditor.UIElements;

public class Resource : GridObject, IMinable
{
    private int amount;

    public Resource(int amount)
    {
        this.amount = amount;
    }

    public Resource SetAmount(int amount)
    {
        this.amount = amount;

        return this;
    }

    public int GetAmount()
    {
        return amount;
    }

    public Resource Mine()
    {
        amount--;

        return new Resource(1);
    } 
}