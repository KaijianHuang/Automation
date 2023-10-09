/**
 * This an implementation for vision module, it will try to connect with ImageSource, and try to detect some object
 * refined from screw fastening project
 * @author Yi Peng Zhu 2023-03-27
 */
#include "Image.h"
#include <iostream>
using namespace std;
#define TARGET_COL 610.098
#define TARGET_ROW 596.882

//"C:/Users/dabao/Desktop/pic1.tif"
Image::Image(const string &imgPath){
    SetSystem("border_shape_models", "false");
    ReadImage(&this->ho_Image, imgPath.c_str());
    GenEllipse(&this->ho_ModelRegion, 486, 624, HTuple(0.367276).TupleRad(), 156.003, 114.975);
    ReduceDomain(this->ho_Image, this->ho_ModelRegion, &this->ho_TemplateImage);

    CreateScaledShapeModel(this->ho_TemplateImage, 6, HTuple(0).TupleRad(), HTuple(180).TupleRad(),
		HTuple(0.8025).TupleRad(), 1.0, 1.0, 0.014, (HTuple("none").Append("no_pregeneration")),
		"use_polarity", ((HTuple(43).Append(58)).Append(4)), 4, &this->hv_ModelID);
    
    //Matching 02: Get the model contour for transforming it later into the image
	GetShapeModelContours(&this->ho_ModelContours, this->hv_ModelID, 1);

    //Matching 02: Get the reference position
	AreaCenter(this->ho_ModelRegion, &this->hv_ModelRegionArea, &this->hv_RefRow, &this->hv_RefColumn);
	VectorAngleToRigid(0, 0, 0, this->hv_RefRow, this->hv_RefColumn, 0, &this->hv_HomMat2D);
	AffineTransContourXld(this->ho_ModelContours, &this->ho_TransContours, this->hv_HomMat2D);
}

bool Image::openCamera(const string &serialID){
    OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default",
		-1, "false", "default", "000748819e0b_TheImagingSourceEuropeGmbH_DFK33GP1300",
		0, -1, &this->hv_AcqHandle);
	SetFramegrabberParam(this->hv_AcqHandle, "Width", 1280);
	SetFramegrabberParam(this->hv_AcqHandle, "Height", 1024);
	GrabImageStart(this->hv_AcqHandle, -1);
}

Position2D Image::detect(double circle_scale){
    Position2D position;
    GrabImageAsync(&this->ho_Image, this->hv_AcqHandle, -1);
    CreateScaledShapeModel(this->ho_TemplateImage, 6, HTuple(0).TupleRad(), HTuple(180).TupleRad(),
			HTuple(0.8025).TupleRad(), circle_scale, circle_scale, 0.014, (HTuple("none").Append("no_pregeneration")),
			"use_polarity", ((HTuple(43).Append(58)).Append(4)), 4, &this->hv_ModelID);

    FindScaledShapeModel(this->ho_Image, this->hv_ModelID, HTuple(0).TupleRad(), HTuple(180).TupleRad(),
        circle_scale, circle_scale, 0.5, 0, 0.5, "least_squares", (HTuple(6).Append(1)), 0.75, &this->hv_Row,
        &this->hv_Column, &this->hv_Angle, &this->hv_Scale, &this->hv_Score);
    int matching_number = 0;
    int bObjectDetected = false;
    try
    {
        matching_number = hv_Score.TupleLength().I();
    }
    catch (const std::exception&)
    {
        bObjectDetected = false;
    }

    if (matching_number >= 1)
    {
        /* 
            Why need fist time flag
            FIXME
            Yi Peng Zhu(yipeng.zhu@siemens.com) 2023-03-27
        */
        // if (objectDetetedFirstTime)
        // {
        //     time_tick00 = GetTickCountA();
        //     objectDetetedFirstTime = false;
        // }
        bObjectDetected = true;
    }
        
    else
    {
        cout << "ERR: No Objects are detected!!! " << endl;
        bObjectDetected = false;
    }
    position.valid = bObjectDetected;
    if(bObjectDetected){
        cout << "hv_Score" << hv_Score[0].D() << endl;
		cout << "hv_Angle" << hv_Angle[0].D() << endl;

        double current_angle = hv_Angle[0].D();
        if (current_angle <= PI/2)
        {
            //clockwise
            current_angle = current_angle;
        }
        else if (current_angle <= PI)
        {
            //counterclockwise
            current_angle = current_angle - PI;
        }
        else
        {
            cout << "RZ angle is more than PI!";
        }
        cout << "current_angle" << current_angle << endl;
        position.angle = current_angle;
        /* 
            No actual work code 
            Yi Peng Zhu(yipeng.zhu@siemens.com) 2023-03-27
        */
        // cout << "center point pixel:" << current_column << "," << current_row << endl;
		// 	if ((current_column - TARGET_COL) > 50 || (current_row - TARGET_ROW) > 50)
		// 		VisionControlMajor = true;
		// 	else
		// 		VisionControlMajor = false;

        position.x = hv_Column[0].D();
		position.y = hv_Row[0].D();
    }
    return position;
}
