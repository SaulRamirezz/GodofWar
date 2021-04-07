using System;
public class HealthSystem
{
    public event EventHandler OnHealthChanged;

    private int health;
    private int healthMax = 100;

    public HealthSystem(int healthMax) //constructor
    {
        this.healthMax = healthMax;
    }

    //public int GetHealth()
    //{
    //    return health;
    //}
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if(OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }

    }
    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }
}
