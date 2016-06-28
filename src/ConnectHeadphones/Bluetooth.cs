using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace ConnectHeadphones
{
  public static class Bluetooth
  {
    public static async Task<BluetoothDeviceInfo[]> Scan()
    {
      return await Task.Run(() =>
      {
        using (var localClient = new BluetoothClient())
        {
          return localClient.DiscoverDevices();
        }
      });
    }

    public static bool Connect(string address)
    {
      return Connect(BluetoothAddress.Parse(address));
    }

    public static bool Connect(BluetoothAddress address)
    {
      using (var localClient = new BluetoothClient())
      {
        localClient.Connect(address, BluetoothService.HeadsetHeadset);
        return new BluetoothDeviceInfo(address).Connected;
      }
    }
  }
}
