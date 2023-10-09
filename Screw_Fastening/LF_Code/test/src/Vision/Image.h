#include <HalconCpp.h>
#include <string>
using namespace HalconCpp;
using namespace std;
typedef struct _Position2D{
    double x;
    double y;
    double angle;
    bool valid;
}Position2D;

class Image {
public:
    Image(const string &imgPath);
    bool openCamera(const string &serialID);
    Position2D detect(double circle_scale);
private:
    // Local iconic variables
    HObject ho_Image;
    HObject ho_ModelRegion;
    HObject ho_TemplateImage;

    HObject ho_ModelContours;
    HObject ho_TransContours;

    HTuple  hv_AcqHandle;
    HTuple  hv_ModelID;
    HTuple  hv_ModelRegionArea;
	HTuple  hv_RefRow;
    HTuple  hv_RefColumn;
    HTuple  hv_HomMat2D;
    HTuple  hv_Row;
    HTuple  hv_Column;
	HTuple  hv_Angle;
    HTuple  hv_Score;
    HTuple  hv_I;
    HTuple  hv_Scale;
    HTuple  hv_ScaleRow;
    HTuple  hv_ScaleColumn;
	HTuple  width0;
    HTuple  height0; 
    HTuple  width1;
    HTuple  height1;
    HTuple  width2;
    HTuple  height2;
    HTuple  width3;
    HTuple  height3;
	HTuple  windowid0;
    HTuple  windowid1;
    HTuple  windowid2;
    HTuple  windowid3;
    HTuple  windowid4;
	HTuple  hv_UsedThreshold;
	int matching_number;
};
