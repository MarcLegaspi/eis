import { IEmployeeAddress } from "./employee-address"

export interface IEmployee {
    id: number
    employeeNumber: string
    lastName: string
    firstName: string
    middleName: string
    suffixName: string
    birthDate: string
    philhealthNo: string
    tin: string
    gsis: string
    telephoneNumber: string
    cellphoneNumber: string
    pictureUrl: string
    position: string
    department: string
    email: string
    password: string
    employeeAddress: IEmployeeAddress
  }