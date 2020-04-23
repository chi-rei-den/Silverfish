using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_305",
  "name": [
    "风驰电掣",
    "Smuggler's Run"
  ],
  "text": [
    "使你手牌中的所有随从牌获得+1/+1。",
    "Give all minions in your hand +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40371
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_305 : SimTemplate //* Smuggler's Run
    {
        // Gige all minions in your hand +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Type == CardType.MINION)
                    {
                        hc.addattack++;
                        hc.addHp++;
                        p.anzOwnExtraAngrHp += 2;
                    }
                }
            }
        }
    }
}