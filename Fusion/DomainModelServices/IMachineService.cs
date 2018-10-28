using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Husky.Services.Device
{
   [ServiceContract]
   public interface IMachineService
   {
      [OperationContract(IsInitiating = false)]
      void ChangeMachineState(short machineId, DateTime timeStamp, MachineMode previousMachineState, MachineMode machineState, ProductionState previousProductionState, ProductionState productionState, string machineDowntimeReason);

      [OperationContract(IsInitiating = false)]
      MfgStandardChangeInfo InitializeDatalogVariables(short machineId, List<VariableDefinitionInfo> machineVariables);

      [OperationContract(IsInitiating = false)]
      void WriteEndOfCycleData(short machineId, DateTime timeStamp, long cycleNumber, double cycleTime, DatalogVariableStatus cycleStatus, AutoScrapType autoScrapRequest, int? scrapReasonId, List<DatalogVariableValue> endOfCycledata);

      [OperationContract(IsInitiating = false)]
      void WriteEndOfCycleDataForMultipleCycles(short machineId, DateTime timeStamp, long cycleNumber, double cycleTime, int numberOfReportedCycles, DatalogVariableStatus cycleStatus, AutoScrapType autoScrapRequest, int? scrapReasonId, List<DatalogVariableValue> endOfCycledata);
      
      [OperationContract(IsInitiating = false)]
      void WriteEndOfCycleDataList(short machineId, int runId, List<EndOfCycleData> cycles);

      [OperationContract(IsInitiating = false)]
      void WriteMachineStateDataList(short machineId, List<MachineStateData> states);

      [OperationContract(IsInitiating = false)]
      void WriteEnergySensorData(string energySensorName, DateTime timestamp, double activePowerConsumption, double reactivePowerConsumption);

   }

   [ServiceContract(Name = "IMachineService")]
   public interface IMachineServiceAsync : IMachineService
   {

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteEndOfCycleData(short machineId, DateTime timeStamp, long cycleNumber, double cycleTime, DatalogVariableStatus cycleStatus, AutoScrapType autoScrapRequest, int? scrapReasonId, List<DatalogVariableValue> endOfCycledata, AsyncCallback callback, object asyncState);
      void EndWriteEndOfCycleData(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteEndOfCycleCurves(short machineId, long cycleNumber, MachineCurve xCurve, List<MachineCurve> ycurves, List<EventMark> markers, CurveSavedReasonType savedReason, bool isQueryCurve, AsyncCallback callback, object asyncState);
      void EndWriteEndOfCycleCurves(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginChangeMachineState(short machineId, DateTime timeStamp, MachineMode previousMachineState, MachineMode machineState, ProductionState previousProductionState, ProductionState productionState, string machineDowntimeReason, AsyncCallback callback, object asyncState);
      void EndChangeMachineState(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteEndOfCycleDataForMultipleCycles(short machineId, DateTime timeStamp, long cycleNumber, double cycleTime, int numberOfReportedCycles, DatalogVariableStatus cycleStatus, AutoScrapType autoScrapRequest, int? scrapReasonId, List<DatalogVariableValue> endOfCycledata, AsyncCallback callback, object asyncState);
      void EndWriteEndOfCycleDataForMultipleCycles(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteEndOfCycleDataList(short machineId, int runId, List<EndOfCycleData> cycles, AsyncCallback callback, object asyncState);
      void EndWriteEndOfCycleDataList(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteMachineStateDataList(short machineId, List<MachineStateData> states, AsyncCallback callback, object asyncState);
      void EndWriteMachineStateDataList(IAsyncResult result);

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginWriteEnergySensorData(string energySensorName, DateTime timestamp, double activePowerConsumption, double reactivePowerConsumption, AsyncCallback callback, object asyncState);
      void EndWriteEnergySensorData(IAsyncResult result);



   }
}
