namespace BTB.GoblinMancer.Systems
{
    public abstract class Damageable
    {
        private const float MAX_HEALTH_POINTS = 100f;
        
        private float _healthPoints = MAX_HEALTH_POINTS;
        
        /// <summary>
        /// Applies damage and returns its alive/dead condition
        /// </summary>
        /// <param name="damage">Amount of health points to receive</param>
        /// <returns>Alive status</returns>
        public bool GetDamage(float damage)
        {
            _healthPoints -= damage;
            return _healthPoints >= 0;
        }
        /// <summary>
        /// Applies health, clamped to maximum health
        /// </summary>
        /// <param name="health">Amount of health points to heal</param>
        public void Heal(float health)
        {
            _healthPoints += health;
            _healthPoints = _healthPoints > MAX_HEALTH_POINTS ? MAX_HEALTH_POINTS : _healthPoints;
        }
    }
}
