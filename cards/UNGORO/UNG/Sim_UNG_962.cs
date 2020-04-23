using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_962",
  "name": [
    "光注剑龙",
    "Lightfused Stegodon"
  ],
  "text": [
    "<b>战吼：</b><b>进化</b>你的白银之手新兵。",
    "<b>Battlecry:</b> <b>Adapt</b> your Silver Hand Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41945
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_962 : SimTemplate //* Lightfused Stegodon
    {
        //Battlecry: Adapt your Silver Hand Recruits.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            var first = true;
            var bestAdapt = 0;
            foreach (var m in temp)
            {
                if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                {
                    if (first)
                    {
                        bestAdapt = p.getBestAdapt(m);
                        first = false;
                    }
                    else
                    {
                        switch (bestAdapt)
                        {
                            case 1:
                                p.minionGetBuffed(m, 1, 1);
                                break;
                            case 2:
                                p.minionGetBuffed(m, 3, 0);
                                break;
                            case 3:
                                p.minionGetBuffed(m, 0, 3);
                                break;
                            case 4:
                                m.taunt = true;
                                break;
                            case 5:
                                m.divineshild = true;
                                break;
                            case 6:
                                m.poisonous = true;
                                break;
                        }
                    }
                }
            }
        }
    }
}