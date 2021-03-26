using Market.Applictaion.Attributes;

namespace Market.Applictaion.Enums
{
    public enum ResponseCode
    {
        #region Fail
        [ResponseCode(ResponseType.Error)]
        Failed,
        [ResponseCode(ResponseType.Error)]
        AlreadyExists,
        [ResponseCode(ResponseType.Error)]
        DoesNotExist,
        #endregion

        #region Success
        [ResponseCode(ResponseType.Success)]
        Success,
        [ResponseCode(ResponseType.Success)]
        SuccesfullyCreated,
        [ResponseCode(ResponseType.Success)]
        SuccessfullyUpdate,
        [ResponseCode(ResponseType.Success)]
        SuccessfullyDeleted,
        #endregion

        #region Info
        [ResponseCode(ResponseType.Info)]
        NoChangesAreDone
        #endregion
    }
}
