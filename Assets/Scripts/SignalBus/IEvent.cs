public interface IEvent
{
    
}
public struct EnemyTakenDamageEvent : IEvent
{
    public int DamageValue;
}