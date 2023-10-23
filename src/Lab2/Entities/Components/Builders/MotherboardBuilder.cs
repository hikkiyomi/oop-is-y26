using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class MotherboardBuilder : IComponentBuilder
{
    private ISocket? _socket;
    private int? _pciLines;
    private int? _sataPorts;
    private int? _ramSlots;
    private IChipset? _chipset;
    private IDdrStandard? _ddrStandard;
    private IFormFactor? _formFactor;
    private Bios? _bios;
    private IWifiModule? _wifiModule;

    public MotherboardBuilder SetSocket(ISocket socket)
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

    public MotherboardBuilder SetChipset(IChipset chipset)
    {
        _chipset = chipset;

        return this;
    }

    public MotherboardBuilder SetDdrStandard(IDdrStandard ddrStandard)
    {
        _ddrStandard = ddrStandard;

        return this;
    }

    public MotherboardBuilder SetFormFactor(IFormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public MotherboardBuilder SetBios(Bios bios)
    {
        _bios = bios;

        return this;
    }

    public MotherboardBuilder SetWifiModule(IWifiModule wifiModule)
    {
        _wifiModule = wifiModule;

        return this;
    }

    public IComponent Build()
    {
        return new Motherboard(
            _socket ?? throw new MotherboardValidationException("Motherboard should have a socket."),
            _pciLines ?? throw new MotherboardValidationException("Motherboard should have at least one PCI-E line."),
            _sataPorts ?? throw new MotherboardValidationException("Motherboard should have at least one SATA port."),
            _ramSlots ?? throw new MotherboardValidationException("Motherboard should have at least one RAM slot"),
            _chipset ?? throw new MotherboardValidationException("Motherboard should have a chipset"),
            _ddrStandard ?? throw new MotherboardValidationException("Motherboard should have a DDR standard"),
            _formFactor ?? throw new MotherboardValidationException("Motherboard should have a form factor"),
            _bios ?? throw new MotherboardValidationException("Motherboard should have a BIOS"),
            _wifiModule);
    }
}