using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Motherboard : IComponent, IPrototype<Motherboard>
{
    public Motherboard(
        Socket socket,
        int pciLines,
        int sataPorts,
        int ramSlots,
        Chipset chipset,
        DdrStandard ddrStandard,
        FormFactor formFactor,
        Bios bios,
        WifiModule? wifiModule)
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

    public Socket Socket { get; }
    public int PciLines { get; }
    public int SataPorts { get; }
    public int RamSlots { get; }
    public Chipset Chipset { get; }
    public DdrStandard DdrStandard { get; }
    public FormFactor FormFactor { get; }
    public Bios Bios { get; }
    public WifiModule? WifiModule { get; }

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

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(Motherboard other)
    {
        return Socket.Equals(other.Socket)
               && PciLines == other.PciLines
               && SataPorts == other.SataPorts
               && RamSlots == other.RamSlots
               && Chipset.Equals(other.Chipset)
               && DdrStandard.Equals(other.DdrStandard)
               && FormFactor.Equals(other.FormFactor)
               && Bios.Equals(other.Bios)
               && Equals(WifiModule, other.WifiModule);
    }
}