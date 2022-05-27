export interface article {
  id: number;
  title: string;
  journalId: number;
  doi: string;
  citiedByCount: number;
  url: string | null;
  sourceName: string | null;
  keywords: string;
  fractialWeight: number | null;
  authorsRaw: string;
}
