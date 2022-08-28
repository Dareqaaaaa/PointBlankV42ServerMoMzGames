﻿using Core;
using Core.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
    public class CLAN_REQUEST_INFO_REC : ReceiveGamePacket
    {
        private long pId;
        public CLAN_REQUEST_INFO_REC(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            pId = readQ();
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                if (player == null)
                    return;
                _client.SendPacket(new CLAN_REQUEST_INFO_PAK(pId, PlayerManager.getRequestText(player.clanId, pId)));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}