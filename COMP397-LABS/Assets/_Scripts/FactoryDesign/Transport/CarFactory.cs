public class CarFactory : AbstractFactory
{
  public override void CreateAgent()
  {
    var agent = Instantiate(AgentPrefab, SpawnLocation.position, SpawnLocation.rotation);
    agent.GetComponent<CarAgent>().Navigate(AgentDestination);
  }
}
