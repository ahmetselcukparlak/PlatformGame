public interface ICharacterHealth
{
    public int Health { get; set; }

    public int GetHealth();
    public void SetHealth(int health);
    public void CanAzalt(int health);
    public void CanArttir(int health);
}