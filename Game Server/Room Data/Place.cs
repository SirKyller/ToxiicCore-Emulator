﻿/*
 _____   ___ __  __  _____ _____   ___  _  __              ___   ___   __    __ 
/__   \ /___\\ \/ /  \_   \\_   \ / __\( )/ _\            / __\ /___\ /__\  /__\
  / /\///  // \  /    / /\/ / /\// /   |/ \ \            / /   //  /// \// /_\  
 / /  / \_//  /  \ /\/ /_/\/ /_ / /___    _\ \          / /___/ \_/// _  \//__  
 \/   \___/  /_/\_\\____/\____/ \____/    \__/          \____/\___/ \/ \_/\__/  
__________________________________________________________________________________

Created by: ToXiiC
Thanks to: CodeDragon, Kill1212, CodeDragon

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Server.Room_Data
{
    class RoomHandler_Place : RoomDataHandler
    {
        public override void Handle(User usr, Room room)
        {
            if (!room.gameactive || usr.Plantings >= 8 || usr.Health <= 0 || !usr.IsAlive()) return;

            //27 = Nexon - 26 = Older clients <- ItemCode

            string item = getBlock(27);

            /* Todo - land status for disable land*/

            if (usr.HasItem(item))
            {
                usr.Plantings++;
                sendBlocks[8] = room.AddPlacement(usr, item);
            }
            else
            {
                usr.disconnect();
            }

            /* Important */

            sendPacket = true;
        }
    }
}
