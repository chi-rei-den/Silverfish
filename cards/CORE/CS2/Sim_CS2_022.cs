using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_022",
  "name": [
    "变形术",
    "Polymorph"
  ],
  "text": [
    "使一个随从变形成为1/1的绵羊。",
    "Transform a minion\ninto a 1/1 Sheep."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 77
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_022 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, CardIds.NonCollectible.Neutral.Sheep);
        }
    }
}