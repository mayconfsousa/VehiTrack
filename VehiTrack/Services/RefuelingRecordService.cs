using VehiTrack.Models;
using VehiTrack.Repositories;

namespace VehiTrack.Services
{
    public class RefuelingRecordsService
    {
        private readonly RefuelingRecordsRepository _refuelingRecordsRepository;

        public RefuelingRecordsService()
        {
            _refuelingRecordsRepository = new RefuelingRecordsRepository();
        }

        public async Task<RefuelingRecord> CreateRefuelingRecordAsync(
            RefuelingRecord refuelingRecord
        )
        {
            var createUser = await _refuelingRecordsRepository.CreateRefuelingRecordAsync(
                refuelingRecord
            );
            return createUser;
        }

        public async Task<RefuelingRecord> UpdateRefuelingRecordAsync(
            RefuelingRecord refuelingRecord
        )
        {
            var updateRefuelingRecord =
                await _refuelingRecordsRepository.UpdateRefuelingRecordAsync(refuelingRecord);
            return updateRefuelingRecord;
        }

        public async Task DeleteRefuelingRecordAsync(RefuelingRecord refuelingRecord)
        {
            await _refuelingRecordsRepository.DeleteRefuelingRecordAsync(refuelingRecord);
        }

        public async Task<ICollection<RefuelingRecord>> GetRefuelingRecords()
        {
            var refuelingRecords = await _refuelingRecordsRepository.GetRefuelingRecordsAsync();
            return refuelingRecords;
        }

        public async Task<RefuelingRecord?> GetRefuelingRecordByIdAsync(int id)
        {
            var refuelingRecord = await _refuelingRecordsRepository.GetRefuelingRecordByIdAsync(id);
            return refuelingRecord;
        }
    }
}