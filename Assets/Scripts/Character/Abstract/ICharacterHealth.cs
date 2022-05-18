public interface ICharacterHealth
{
    public float Health { get; set; }

    public float GetHealth();
    public void SetHealth(float health);
    public void CanAzalt(float health);
    public void CanArttir(float health);
}