using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_027",
  "name": [
    "镜像",
    "Mirror Image"
  ],
  "text": [
    "召唤两个0/2，并具有<b>嘲讽</b>的随从。",
    "Summon two 0/2 minions with <b>Taunt</b>."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1084
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_027 : SimTemplate //* mirrorimage
    {
        //Summon two 0/2 minions with Taunt.

        SimCard kid = CardIds.NonCollectible.Mage.MirrorImage;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
            p.callKid(this.kid, pos, ownplay);
        }
    }
}