using Lab3_PonomarevaFO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_PonomarevaFO
{
    public class Controller
    {
        private readonly IDataTransfer _dataTransfer;
        private readonly DbWorker _worker;
        private readonly TypeTriangle2 _typeTriangle2;
        private readonly IUserInterface _userInterface;

        public Controller(IDataTransfer dataTransfer, DbWorker worker, TypeTriangle2 typeTriangle2, IUserInterface userInterface)
        {
            _dataTransfer = dataTransfer;
            _worker = worker;
            _typeTriangle2 = typeTriangle2;
            _userInterface = userInterface;
        }

        public string AddComment()
        {
            {
            
                _userInterface.GetUserInput();

                List<TypeTriangle> triangles = _worker.GetData();

                
                bool dataExists = false;

                foreach (TypeTriangle triangle in triangles)
                {
                    if (triangle.Length1 == _typeTriangle2.SideA && triangle.Length2 == _typeTriangle2.SideB && triangle.Length3 == _typeTriangle2.SideC)
                    {
                        dataExists = true;
                        break;
                    }
                }

                if (!dataExists)
                {
                    
                    (string triangleType, List<(int, int)> coordinates) result = TypeTriangle2.CalculateTriangleType(_typeTriangle2.SideA, _typeTriangle2.SideB, _typeTriangle2.SideC, _typeTriangle2.A, _typeTriangle2.B, _typeTriangle2.C, _typeTriangle2.Ax, _typeTriangle2.Ay, _typeTriangle2.Bx, _typeTriangle2.By, _typeTriangle2.Cx, _typeTriangle2.Cy);

                    
                    _worker.AddData(_typeTriangle2.SideA, _typeTriangle2.SideB, _typeTriangle2.SideC, result.triangleType, "");

                  
                    _dataTransfer.Send(result.triangleType);

                    return result.triangleType;
                }
                else
                {
                   
                    string result = "";

                    foreach (TypeTriangle triangle in triangles)
                    {
                        if (triangle.Length1 == _typeTriangle2.SideA && triangle.Length2 == _typeTriangle2.SideB && triangle.Length3 == _typeTriangle2.SideC)
                        {
                            result = triangle.TriangleType;
                            break;
                        }
                    }

                    _dataTransfer.Send(result);

                    return result;
                }
            }
        }
    }
}

       

