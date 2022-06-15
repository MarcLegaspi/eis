import { IEmployeeAddress } from "./employee-address";

export interface IEmployeeForm {
    id: number;
    employeeNumber: string;
    lastName: string;
    firstName: string;
    middleName: string;
    suffixName: string;
    birthDate: Date;
    philhealthNo: string;
    tin: string;
    gsis: string;
    sss: string;
    pagibig: string;
    pictureUrl: string;
    dateHired: Date;
    positionId: number;
    email: string;
    contactPerson: string;
    contactPersonCellphoneNumber: string;
    contactPersonRelationship: number;
    cellphoneNumber: string;
    telephoneNumber: string;
    companyEmail: string;
    employeeAddress: IEmployeeAddress;
}