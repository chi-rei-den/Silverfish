using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_110 : SimTemplate //Dr. Boom
    {

        //  Battlecry: Summon two 1/1 Boom Bots. WARNING: Bots may explode. 

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_110t);//chillwind

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos, own.own);
            p.callKid(kid, own.zonepos - 1, own.own);
        }


    }

}