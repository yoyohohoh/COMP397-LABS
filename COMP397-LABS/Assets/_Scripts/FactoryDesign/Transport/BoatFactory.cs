public class BoatFactory : AbstractFactory
{
  public override void CreateAgent()
  {
    var agent = Instantiate(AgentPrefab, SpawnLocation.position, SpawnLocation.rotation);
    agent.GetComponent<BoatAgent>().Navigate(AgentDestination);
  }
}
