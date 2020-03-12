using System;
using System.Management.Automation;
namespace TMySCCmdLet
{
    [Cmdlet(VerbsCommon.Get, "TMySimpleCalc", DefaultParameterSetName =
   "Standard")]
    public class TMySimpleCalc : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Standard",
       HelpMessage = "Zeichenkette für den ersten Operanden eingeben.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName =
       "Wissenschaftlich", HelpMessage = "Zeichenkette für den ersten Operanden eingeben.")]
        public String zahl1 { get; set; }
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Standard",
       HelpMessage = "Zeichenkette für den zweiten Operanden eingeben.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName =
       "Wissenschaftlich", HelpMessage = "Zeichenkette für den zweiten Operanden eingeben.")]
        public String zahl2 { get; set; }
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Standard",
       HelpMessage = "Zeichenkette für den Operator eingeben.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName =
       "Wissenschaftlich", HelpMessage = "Zeichenkette für den Operator eingeben.")]
        public String op { get; set; }
        [Parameter(Position = 3, Mandatory = false, ParameterSetName =
       "Standard", HelpMessage = "Zeichenkette für den das Zwischenergebnis der Prozentrechnung eingeben.")]
        [Parameter(Position = 3, Mandatory = false, ParameterSetName =
       "Wissenschaftlich", HelpMessage = "Zeichenkette für den das Zwischenergebnis der Prozentrechnung eingeben.")]
        public String proz { get; set; }
        [Parameter(Position = 4, Mandatory = false, ParameterSetName =
       "Standard", HelpMessage = "Zeichenkette für den Zwischenspeicher für den Prozentrechnungsoperator eingeben.")]
        [Parameter(Position = 4, Mandatory = false, ParameterSetName =
       "Wissenschaftlich", HelpMessage = "Zeichenkette für den Zwischenspeicher für den Prozentrechnungsoperator eingeben.")]
        public String prozop { get; set; }
        private Double erg { get; set; }
        private Double z1 { get; set; }
        private Double z2 { get; set; }
        protected override void BeginProcessing()
        {
            erg = 0;
            z1 = Double.Parse(zahl1,
           System.Globalization.CultureInfo.InvariantCulture);
            z2 = Double.Parse(zahl2,
           System.Globalization.CultureInfo.InvariantCulture);
        }
        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
        protected override void ProcessRecord()
        {
            switch (op)
            {
                case "Plus":
                    erg = z1 + z2;
                    break;
                case "Minus":
                    erg = z1 - z2;
                    break;
                case "Mul":
                    erg = z1 * z2;
                    break;
                case "Div":
                    try
                    {
                        if (z2 == 0)
                            throw new DivideByZeroException("Division durch 0 nicht erlaubt");
                           
                            erg = z1 / z2;

                        WriteObject(erg.ToString(System.Globalization.CultureInfo.InvariantCulture),
                        true);
                    }
                    catch (Exception e)
                    {
                        ErrorRecord errorRecord = new
                       ErrorRecord(e, e.HResult.ToString(), ErrorCategory.InvalidOperation, e.Data.ToString
                       ());
                        WriteError(errorRecord);
                    }
                    break;
            }

            WriteObject(erg.ToString(System.Globalization.CultureInfo.InvariantCulture),
            true);
        }
        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}