using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_005",
  "name": [
    "变形术：野猪",
    "Polymorph: Boar"
  ],
  "text": [
    "使一个随从变形成为一个4/2并具有<b>冲锋</b>的野猪。",
    "Transform a minion into a 4/2 Boar with <b>Charge</b>."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2542
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_005 : SimTemplate //* Polymorph: Boar
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, CardIds.NonCollectible.Neutral.PolymorphBoar_BoarToken);
        }
    }
}