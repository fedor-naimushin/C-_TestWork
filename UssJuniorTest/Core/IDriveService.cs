using UssJuniorTest.Core.Contracts;

namespace UssJuniorTest.Core;

public interface IDriveService
{
    List<DriveInfoResponse> GetDriveInfo(TimeRangeRequest request);
}