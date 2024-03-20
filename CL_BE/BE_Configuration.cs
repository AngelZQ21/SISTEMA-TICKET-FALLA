using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Configuration:BE_Audit
    {
       public int  IdConfiguration {set;get;}
       public int  ZCSyncTime {set;get;}
       public int  EmbeddedQuantityDays {set;get;}
       public int  MinDate {set;get;}
       public string  StockRestriction {set;get;}
       public string PrefixSetting { set; get; }
       public int  DecimalQuantity {set;get;}
       public int  DecimalQuantity2 {set;get;}
       public int  MaxRowsReport {set;get;}
       public int  MaxRowsSummary {set;get;}
       public int  MaxRowsGraphic {set;get;}
       public int  MaxDataGraphic {set;get;}
       public string PathFile { set; get; }
       public string PathFileInput { set; get; }
       public string PathFileOut { set; get; }
       public string PathFileDencrypt { set; get; }
       public string PathFileTemp { set; get; }
       public string PathSystem { set; get; }
       public string PathFileDispatchOk { set; get; }
       public string PathFileDispatchError { set; get; }
       public int  TypeLoginZeus {set;get;}
       public int  LogBus {set;get;}
       public int  LogDispatch {set;get;}
       public int  LogProtocol {set;get;}
       public int  logError {set;get;}
       public int  Migration_BlackList_Driver {set;get;}
       public int  Migration_BlackList_Vehicle {set;get;}
       public int  Migration_Driver {set;get;}
       public int  Migration_Operator {set;get;}
       public int  Migration_Vehicle {set;get;}
       public int  DefaultStation {set;get;}
       public decimal  PercentVIMS {set;get;}
       public bool  ValidateVehicle {set;get;}
       public bool ValidateOperator { set; get; }
       public bool ValidateDriver { set; get; }
       public bool Sound { set; get; }
       public int  MaxColumnRestriction {set;get;}
       public int  NumberLockType {set;get;}
       public int  MaxTimeBombas {set;get;}
       public int MaxTimeNoFujo { set; get; }
       public string AlertStatus { set; get; }
    }
}
