import java.io.FileOutputStream;
import java.io.IOException;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

class _09_DeckOfCards {

	public static final String RESULT = "Deck-Of-Cards.pdf";

	public static void main(String[] args) throws DocumentException, IOException {
		new _09_DeckOfCards().createPdf(RESULT);
	}

	public void createPdf(String filename) throws DocumentException, IOException {
		Document document = new Document();
		PdfWriter.getInstance(document, new FileOutputStream(filename));
		document.open();

		BaseFont base = BaseFont.createFont("lib/lucida.ttf", BaseFont.IDENTITY_H, true);
		Font blackFont = new Font(base, 25f, 0, BaseColor.BLACK);
		Font redFont = new Font(base, 25f, 0, BaseColor.RED);

		char[] suit = { '♣', '♦', '♥', '♠' };

		for (int i = 2; i < 15; i++) {

			PdfPTable table = new PdfPTable(7);
			PdfPTable rowsSpace = new PdfPTable(1);
			table.setWidthPercentage(65.067f);
			rowsSpace.setWidthPercentage(60.067f);
			table.setWidths(new int[] { 4, 1, 4, 1, 4, 1, 4 });
			PdfPCell cell;

			String face = "" + i;

			switch (i) {
			case 11:
				face = "J";
				break;
			case 12:
				face = "Q";
				break;
			case 13:
				face = "K";
				break;
			case 14:
				face = "A";
				break;
			}

			for (int j = 0; j < suit.length; j++) {

				String card = face + " " + suit[j];

				if (j == 1 || j == 2) {
					cell = new PdfPCell(new Phrase(card, redFont));
				} else {
					cell = new PdfPCell(new Phrase(card, blackFont));
				}

				cell.setFixedHeight(100f);
				cell.setVerticalAlignment(Element.ALIGN_MIDDLE);
				cell.setHorizontalAlignment(Element.ALIGN_CENTER);

				table.addCell(cell);

				if (j != 3) {
					cell = new PdfPCell(new Phrase("", blackFont));
					cell.setBorder(0);
					table.addCell(cell);
				}
			}
			cell = new PdfPCell(new Phrase("", blackFont));
			cell.setFixedHeight(10f);
			cell.setBorder(0);
			rowsSpace.addCell(cell);

			document.add(rowsSpace);
			document.add(table);
		}
		document.close();
	}
	
}