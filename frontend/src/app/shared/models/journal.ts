export interface journal {
  id: number;
  title:number;
  issn: string;
  volume: number;
  part: number | null;
  year: number;
  quartil: string | null;
  indexator: string;
  issue : string;
  createdAt: string;
  updatedAt: string;
  eissn: string;
}
