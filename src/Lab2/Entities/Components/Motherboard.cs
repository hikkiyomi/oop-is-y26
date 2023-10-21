using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Motherboard : IComponent, IPrototype<Motherboard>
{
    public Motherboard(
        ISocket socket,
        int pciLines,
        int sataPorts,
        int ramSlots,
        IChipset chipset,
        IDdrStandard ddrStandard,
        IFormFactor formFactor,
        Bios bios,
        IWifiModule? wifiModule)
    {
        Socket = socket;
        PciLines = pciLines;
        SataPorts = sataPorts;
        RamSlots = ramSlots;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        FormFactor = formFactor;
        Bios = bios;
        WifiModule = wifiModule;
    }

    public ISocket Socket { get; }
    public int PciLines { get; }
    public int SataPorts { get; }
    public int RamSlots { get; }
    public IChipset Chipset { get; }
    public IDdrStandard DdrStandard { get; }
    public IFormFactor FormFactor { get; }
    public Bios Bios { get; }
    public IWifiModule? WifiModule { get; }

    public Motherboard Clone()
    {
        return new Motherboard(
            Socket,
            PciLines,
            SataPorts,
            RamSlots,
            Chipset,
            DdrStandard,
            FormFactor,
            Bios,
            WifiModule);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}