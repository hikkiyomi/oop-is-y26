using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class MotherboardBuilder : IComponentBuilder
{
    private Socket? _socket;
    private int? _pciLines;
    private int? _sataPorts;
    private int? _ramSlots;
    private Chipset? _chipset;
    private DdrStandard? _ddrStandard;
    private FormFactor? _formFactor;
    private Bios? _bios;
    private WifiModule? _wifiModule;

    public void Reset()
    {
        _socket = null;
        _pciLines = null;
        _sataPorts = null;
        _ramSlots = null;
        _chipset = null;
        _ddrStandard = null;
        _formFactor = null;
        _bios = null;
        _wifiModule = null;
    }

    public MotherboardBuilder SetSocket(Socket socket)
    {
        _socket = socket;

        return this;
    }

    public MotherboardBuilder SetPciLinesAmount(int pciLines)
    {
        _pciLines = pciLines;

        return this;
    }

    public MotherboardBuilder SetSataPortsAmount(int sataPorts)
    {
        _sataPorts = sataPorts;

        return this;
    }

    public MotherboardBuilder SetRamSlotsAmount(int ramSlots)
    {
        _ramSlots = ramSlots;

        return this;
    }

    public MotherboardBuilder SetChipset(Chipset chipset)
    {
        _chipset = chipset;

        return this;
    }

    public MotherboardBuilder SetDdrStandard(DdrStandard ddrStandard)
    {
        _ddrStandard = ddrStandard;

        return this;
    }

    public MotherboardBuilder SetFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public MotherboardBuilder SetBios(Bios bios)
    {
        _bios = bios;

        return this;
    }

    public MotherboardBuilder SetWifiModule(WifiModule wifiModule)
    {
        _wifiModule = wifiModule;

        return this;
    }

    public IComponent Build()
    {
        var motherboard = new Motherboard(
            _socket ?? throw new MotherboardValidationException("Motherboard should have a socket."),
            _pciLines ?? throw new MotherboardValidationException("Motherboard should have at least one PCI-E line."),
            _sataPorts ?? throw new MotherboardValidationException("Motherboard should have at least one SATA port."),
            _ramSlots ?? throw new MotherboardValidationException("Motherboard should have at least one RAM slot"),
            _chipset ?? throw new MotherboardValidationException("Motherboard should have a chipset"),
            _ddrStandard ?? throw new MotherboardValidationException("Motherboard should have a DDR standard"),
            _formFactor ?? throw new MotherboardValidationException("Motherboard should have a form factor"),
            _bios ?? throw new MotherboardValidationException("Motherboard should have a BIOS"),
            _wifiModule);

        Reset();

        return motherboard;
    }
}