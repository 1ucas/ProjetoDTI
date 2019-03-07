using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.ServiceModel.Channels;


namespace EstoqueWCF
{
    [ServiceContract]
    public interface IEstoqueService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Produto> encontraTodos();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Produto encontra(int id);

        [OperationContract]
        Produto novo(Produto produto);

        [OperationContract]
        Produto atualiza(Produto produto);

        [OperationContract]
        Produto deletaID(int id);

        [OperationContract]
        Produto deleta(Produto produto);
    }

    public class ReferencePreservingDataContractFormatAttribute
       : Attribute, IOperationBehavior
    {
        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description,
            BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description,
            ClientOperation proxy)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyClientBehavior(description, proxy);
        }

        public void ApplyDispatchBehavior(OperationDescription description,
            DispatchOperation dispatch)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyDispatchBehavior(description, dispatch);
        }

        public void Validate(OperationDescription description)
        {
        }

        #endregion
    }



    public class ReferencePreservingDataContractSerializerOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        #region Ctor
        public ReferencePreservingDataContractSerializerOperationBehavior(
            OperationDescription operationDescription)
            : base(operationDescription) { }
        #endregion

       
    }
}
