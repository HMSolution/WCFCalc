using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStarted
{
    // Definition eines service contracts => Spezifizierung welche Operationen unterstützt werden
    [ServiceContract (Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        //OperationConract dieses Attribut muss über zugängliche Methoden geschrieben werden
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract] // Es wird keine Antwort an den Client gesendet, eigentlich für Voids vorgesehen, um clients nicht mit leeren Nachrichten zu freezen
        double Divide(double n1, double n2);
    }
}
